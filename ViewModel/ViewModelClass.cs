using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Task_2_2.Model;

namespace Task_2_2.ViewModel
{
    class ViewModelClass : INotifyPropertyChanged
    {
        private Airplane airplane;
        private Helicopter helicopter;
        private int currentAirplaneRunwayLength;
        private int currentAirplaneHeightAboveGroundForView;
        private bool isFlyingSuccesfullForAirplane;
        private int currentHelicopterHeightAboveGroundForView;

        public ViewModelClass(Airplane airplane, Helicopter helicopter)
        {
            this.airplane = airplane;
            this.helicopter = helicopter;

            currentAirplaneHeightAboveGroundForView = airplane.CurrentHeightAboveGround;
            IsFlyingSuccesfullForAirplane = false;

            CurrentHelicopterHeightAboveGroundForView = helicopter.CurrentHeightAboveGround;

            airplane.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(airplane.CurrentRunwayLength))
                {
                    CurrentAirplaneRunwayLength = airplane.CurrentRunwayLength;
                } else if (e.PropertyName == nameof(airplane.CurrentHeightAboveGround))
                {
                    CurrentAirplaneHeightAboveGroundForView = airplane.CurrentHeightAboveGround;

                }
            };

            helicopter.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(helicopter.CurrentHeightAboveGround))
                {
                    CurrentHelicopterHeightAboveGroundForView = helicopter.CurrentHeightAboveGround;
                }
            };

        }

        public int CurrentAirplaneRunwayLength
        {
            get
            {
                return currentAirplaneRunwayLength;
            }
            set
            {
                //currentAirplaneRunwayLength = value;
                airplane.CurrentRunwayLength = value;

            }
        }

        public int CurrentAirplaneHeightAboveGroundForView
        {
            get
            {
                return currentAirplaneHeightAboveGroundForView;
            }
            set
            {
                currentAirplaneHeightAboveGroundForView = value;
                NotifyPropertyChanged(nameof(CurrentAirplaneHeightAboveGroundForView));
            }
        }

        public bool IsFlyingSuccesfullForAirplane
        {
            get
            {
                return isFlyingSuccesfullForAirplane;
            }
            set
            {
                isFlyingSuccesfullForAirplane = value;
                NotifyPropertyChanged(nameof(IsFlyingSuccesfullForAirplane));
                //TODO: сделать невидимым. А потом - веролёт. Visibility!!!
            }
        }

        public int CurrentHelicopterHeightAboveGroundForView
        {
            get
            {
                return currentHelicopterHeightAboveGroundForView;
            }
            set
            {
                currentHelicopterHeightAboveGroundForView = value;
                NotifyPropertyChanged(nameof(CurrentHelicopterHeightAboveGroundForView));
            }
        }






        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }






        private CommandClass upAirplaneCommand;
        public CommandClass UpAirplaneCommand
        {
            get
            {
                return upAirplaneCommand ??
                    (upAirplaneCommand = new CommandClass(obj =>
                    {
                        airplane.CurrentRunwayLength = Convert.ToInt32((string)obj);
                        IsFlyingSuccesfullForAirplane = airplane.Up();
                    }));
            }
        }

        private CommandClass downAirplaneCommand;
        public CommandClass DownAirplaneCommand
        {
            get
            {
                return downAirplaneCommand ??
                    (downAirplaneCommand = new CommandClass(obj =>
                    {
                        airplane.CurrentRunwayLength = Convert.ToInt32((string)obj);
                        IsFlyingSuccesfullForAirplane = airplane.Down();
                    }));
            }
        }

        private CommandClass upHelicopterCommand;
        public CommandClass UpHelicopterCommand
        {
            get
            {
                return upHelicopterCommand ??
                    (upHelicopterCommand = new CommandClass(obj =>
                    {
                        helicopter.Up();
                    }));
            }
        }

        private CommandClass downHelicopterCommand;
        public CommandClass DownHelicopterCommand
        {
            get
            {
                return downHelicopterCommand ??
                    (downHelicopterCommand = new CommandClass(obj =>
                    {
                        helicopter.Down();
                    }));
            }
        }
    }
}
