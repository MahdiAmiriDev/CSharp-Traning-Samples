using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStore.Model.FrameWork
{
    /// <summary>
    /// روشی برای هندل کردن این که آیا عملیات کراد ما موفق بوده یا نه 
    /// </summary>
    public class ApplicationServiceResponse
    {
        private readonly List<string> _errors = new List<string>();
        /// <summary>
        /// اگر فیلیر نبود پس موفقیت آمیز بر میگردانیم
        /// </summary>
        public bool IsSuccess => !IsFailur;
        /// <summary>
        /// اگر ارور ها دارای مقدار بود ترو می شود به معنای داشتن خطا
        /// اگر ارور های ما خالی بود پس به معنای عدم وجود خطا است 
        /// </summary>
        public bool IsFailur => _errors.Any();
        
        public void AddError(string errorMessage)
        {
            _errors.Add(errorMessage);
        }

        public IReadOnlyList<string> Errors => _errors;
    }
    /// <summary>
    /// اگر نوع ریزالت هم مهم بود از این کلاس استفاده می کینم
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public class ApplicationServiceResponse<TResult> : ApplicationServiceResponse
    {
        public TResult Result { get; set; }
    }
}
