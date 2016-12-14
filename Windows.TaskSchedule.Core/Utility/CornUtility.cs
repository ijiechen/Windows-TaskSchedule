using System;
using Windows.TaskSchedule.Core.Corn.Net;

namespace Windows.TaskSchedule.Core.Utility
{
    public class CornUtility
    {
        public static bool Trigger(string cornExpress, DateTime dateUtc)
        {
            if(!CronExpression.IsValidExpression(cornExpress)){
                throw new Exception(string.Format("corn表达式：{0}不正确。",cornExpress));
            }
            CronExpression corn = new CronExpression(cornExpress);
            return corn.IsSatisfiedBy(dateUtc);
        }       
    }
}
