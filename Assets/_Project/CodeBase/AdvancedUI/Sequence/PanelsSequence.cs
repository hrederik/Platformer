using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace AdvancedUI.Sequence
{
    public class PanelsSequence : ShowableScreen
    {
        [SerializeField] private MonoBehaviour[] _panelsBehaviour;
        private IPanel[] _panels;
        private List<IPanel> _sequence;
        private IPanel _current;

        private IPanel[] Panels => 
            _panels ??= ConvertPanels();

        private void OnValidate()
        {
            foreach (var panel in _panelsBehaviour) 
                InterfaceValidator.TryToValidate<IPanel>(panel);
        }

        private void Awake()
        {
            _sequence = new List<IPanel>();
        }

        private void OnEnable()
        {
            foreach (var panel in Panels)
            {
                panel.Ready += OnPanelReady;
                panel.Closed += OnPanelClosed;
            }
        }

        private void OnDisable()
        {
            foreach (var panel in Panels)
            {
                panel.Ready -= OnPanelReady;
                panel.Closed -= OnPanelClosed;
            }
        }

        public override void Show()
        {
            if (_current == null)
                ShowNext();
        }

        public override Coroutine Hide()
        {
            _current?.Hide();
            _sequence = new List<IPanel>();

            return StartEmptyCoroutine();
        }

        private void OnPanelReady(IPanel item)
        {
            _sequence.Add(item);
        }

        private void OnPanelClosed()
        {
            if (_sequence.Count > 0)
                ShowNext();
            else
                _current = null;
        }

        private void ShowNext()
        {
            _current = _sequence[0];
            _sequence.Remove(_current);
            _current.Spawn();
        }

        private IPanel[] ConvertPanels()
        {
            var panels = new IPanel[_panelsBehaviour.Length];

            for (int i = 0; i < panels.Length; i++) 
                panels[i] = (IPanel) _panelsBehaviour[i];
            
            return panels;
        }
    }
}