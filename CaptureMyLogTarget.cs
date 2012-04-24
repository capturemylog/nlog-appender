using CaptureMyLog.Framework;
using NLog;
using NLog.Targets;

namespace CaptureMyLog.NLog
{
    [Target("CaptureMyLogTarget")]
    public class CaptureMyLogTarget : TargetWithLayout
    {
        #region Properties

        public string ApplicationKey { get; set; }
        public string OwnerKey { get; set; }
        public string DeviceKey { get; set; }
        public bool IsTakingPictureEnabled { get; set; }

        #endregion Properties

        #region Overriden Members

        protected override void Write(LogEventInfo logEvent)
        {
            byte[] picture = null;
            if (this.IsTakingPictureEnabled)
                picture = Helpers.CaptureScreenAsJpeg();

            //LogDataWrapper.LogNewDataAsync(this.ApplicationKey, this.DeviceKey, this.OwnerKey, logEvent.FormattedMessage, logEvent.Level.Name, picture);
            LogDataWrapper.LogNewData(this.ApplicationKey, this.DeviceKey, this.OwnerKey, logEvent.FormattedMessage, logEvent.Level.Name, picture);
        }

        #endregion Overriden Members
    }
}