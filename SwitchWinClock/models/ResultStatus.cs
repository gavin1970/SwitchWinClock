namespace SwitchWinClock.models
{
    public enum RESULT_STATUS
    {
        OK,
        FAIL,
        MISSING,
        EXCEPTION
    }

    public class ResultStatus
    {
        public RESULT_STATUS Status { get; set; } = RESULT_STATUS.OK;
        public string Description { get; set; } = "";
        public string StackTrace { get; set; } = "";
    }
}
