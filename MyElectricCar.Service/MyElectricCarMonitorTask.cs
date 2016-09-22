using System;
using System.Diagnostics;
using Windows.ApplicationModel.Background;
using Windows.System.Threading;

namespace MyElectricCar.Service
{
    public sealed class MyElectricCarMonitorTask : IBackgroundTask
    {
        IBackgroundTaskInstance _taskInstance = null;
        BackgroundTaskCancellationReason _cancelReason = BackgroundTaskCancellationReason.Abort;
        BackgroundTaskDeferral _deferral = null;
        ThreadPoolTimer _periodicTimer = null;
        volatile bool _cancelRequested = false;

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            Debug.WriteLine("Service Run");
            taskInstance.Canceled += new BackgroundTaskCanceledEventHandler(OnCanceled);

            _deferral = taskInstance.GetDeferral();
            _taskInstance = taskInstance;
            _periodicTimer = ThreadPoolTimer.CreatePeriodicTimer(new TimerElapsedHandler(PeriodicTimerCallback), TimeSpan.FromSeconds(60));
        }

        private void OnCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
        {
            _cancelRequested = true;
            _cancelReason = reason;

            Debug.WriteLine($"Background '{sender.Task.Name}' Cancel Requested...");
        }

        private void PeriodicTimerCallback(ThreadPoolTimer timer)
        {
            if (_cancelRequested == false)
            {
                Debug.WriteLine($"Delay: '{timer.Delay}', Perid: '{timer.Period}'");
            }
            else
            {
                Debug.WriteLine($"Background '{_taskInstance.Task.Name}' Cancel Reason: '{_cancelReason}'");
                _deferral.Complete();
            }
        }
    }
}
