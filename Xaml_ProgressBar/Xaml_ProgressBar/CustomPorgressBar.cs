using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Xaml_ProgressBar
{
    class CustomPorgressBar: ProgressBar
    {
        public static readonly RoutedEvent AlertEvent = EventManager.RegisterRoutedEvent("Alert", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(CustomPorgressBar));
        private int _AlertLevel;
        public int AlertLevel
        {
            get
            {
                return this._AlertLevel;
            }
            set
            {
                if(value<Maximum && value > Minimum)
                {
                    this._AlertLevel = value;
                }
                else
                {
                    throw new Exception("BOOM");
                }
            }
        }
        
        public new double Value
        {
            get
            {
                return base.Value;
            }
            set
            {
                base.Value = value;
                if(Value > this._AlertLevel)
                {
                    RaiseEvent(new RoutedEventArgs(AlertEvent));
                }
            }
        }
        public event RoutedEventHandler Alert
        {
            add
            {
                this.AddHandler(CustomPorgressBar.AlertEvent, value);
            }
            remove
            {
                this.RemoveHandler(CustomPorgressBar.AlertEvent, value);
            }
        }
    }
}
