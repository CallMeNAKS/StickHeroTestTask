using Zenject;

namespace CodeBase.Infrastructure.Parallax
{
    using UnityEngine;

    public class ParallaxEffect : MonoBehaviour
    {
        [System.Serializable]
        private class ParallaxLayer
        {
            public Transform[] _segments; // Сегменты слоя
            public float _parallaxFactor; // Фактор параллакса (скорость слоя относительно камеры)
            public float _buffer; // Запас, чтобы не было раннего выключения
            public int _sortingOrder; // Sorting Order для сегментов слоя
        }

        [SerializeField] private ParallaxLayer[] _layers;
        [SerializeField] private Camera _camera;

        private Vector3 _previousCameraPosition;

        [Inject]
        public void Construct(Camera camera)
        {
            _camera = camera;
        }

        private void Start()
        {
            _previousCameraPosition = _camera.transform.position;
        }

        private void Update()
        {
            Vector3 cameraDelta = _camera.transform.position - _previousCameraPosition;

            foreach (var layer in _layers)
            {
                foreach (var segment in layer._segments)
                {
                    // Двигаем сегменты пропорционально смещению камеры и фактору параллакса
                    segment.position -= new Vector3(cameraDelta.x * layer._parallaxFactor / 5, 0, 0);

                    // Если сегмент выходит за пределы камеры + buffer, переносим его вперед
                    float segmentWidth = GetSegmentWidth(segment);
                    if (segment.position.x < _camera.transform.position.x - segmentWidth / 2 - layer._buffer)
                    {
                        MoveSegmentForward(segment, layer, segmentWidth);
                    }
                }
            }

            _previousCameraPosition = _camera.transform.position;
        }

        private void MoveSegmentForward(Transform segment, ParallaxLayer layer, float segmentWidth)
        {
            Transform lastSegment = GetLastSegment(layer);
            segment.position = lastSegment.position + Vector3.right * segmentWidth;
        }

        private Transform GetLastSegment(ParallaxLayer layer)
        {
            Transform lastSegment = layer._segments[0];
            foreach (var segment in layer._segments)
            {
                if (segment.position.x > lastSegment.position.x)
                {
                    lastSegment = segment;
                }
            }

            return lastSegment;
        }

        private float GetSegmentWidth(Transform segment)
        {
            Renderer renderer = segment.GetComponent<Renderer>();
            if (renderer != null)
            {
                return renderer.bounds.size.x;
            }

            Debug.LogWarning($"No Renderer found on segment {segment.name}. Using default width of 1.");
            return 1.0f; // Значение по умолчанию, если отсутствует Renderer
        }

        public void ResetParallax()
        {
            foreach (var layer in _layers)
            {
                float segmentWidth = GetSegmentWidth(layer._segments[0]);

                for (int i = 0; i < layer._segments.Length; i++)
                {
                    Transform segment = layer._segments[i];

                    // Сохраняем высоту (Y) текущего сегмента
                    float originalY = segment.position.y;

                    // Расставляем сегменты на новой позиции
                    segment.position = new Vector3(
                        _camera.transform.position.x - segmentWidth / 2 + segmentWidth * i,
                        originalY, // Используем исходную высоту
                        segment.position.z
                    );

                    // Применяем Sorting Order для слоя
                    Renderer renderer = segment.GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        renderer.sortingOrder = layer._sortingOrder;
                    }
                }
            }

            // Обновляем предыдущую позицию камеры
            _previousCameraPosition = _camera.transform.position;
        }
    }
}