using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LINCHANGZHI7324
{
    public class CardTaxFather
    {
        /// <summary>
        /// 算出總金額 
        /// </summary>
        /// <param name="startTime">開始年月日</param>
        /// <param name="endTime">結束年月日</param>
        /// <param name="price">一年的金額</param>
        /// <returns>回傳總金額double</returns>
        public double countResult(DateTime startTime, DateTime endTime, int price)
        {


            if (startTime.Year == endTime.Year)
            {
                TimeSpan ii = endTime - startTime;
                double dd = ii.TotalDays * price;
                if (isLeapYear(startTime.Year) == true)
                {
                    return dd / 366;
                }
                else
                {
                    return dd / 360;
                }

            }
            else if (startTime.Year < endTime.Year)
            {
                int middleStartYear = startTime.Year;
                DateTime startTimeYearEndDate = new DateTime(startTime.Year, 12, 31);
                DateTime endTimeYearEndDate = new DateTime(endTime.Year, 1, 1);
                TimeSpan startTimeSpan = startTimeYearEndDate - startTime;
                TimeSpan endTimeSpan = endTime - endTimeYearEndDate;
                int startTimeisornotisLeapYear;
                int endTimeisornotisLeapYear;

                if (isLeapYear(startTime.Year))
                {
                    startTimeisornotisLeapYear = 365;
                }
                else
                {
                    startTimeisornotisLeapYear = 366;
                }
                if (isLeapYear(endTime.Year))
                {
                    endTimeisornotisLeapYear = 365;
                }
                else
                {
                    endTimeisornotisLeapYear = 366;
                }
                return ((endTime.Year - startTime.Year - 1) * price) + ((startTimeSpan.Days) * price / startTimeisornotisLeapYear) + ((endTimeSpan.Days) * price / endTimeisornotisLeapYear);
            }
            else
            {
                return -1;
            }
        }

        public bool isLeapYear(int year)
        {
            if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0))
            {
                //該年是閏年
                return true;
            }
            else
            {
                //該年不是閏年
                return false;
            }
        }

     

    }
    
}
