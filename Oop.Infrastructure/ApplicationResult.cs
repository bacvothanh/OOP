using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oop.Infrastructure.Extensions;
using Oop.Infrastructure.Helpers;

namespace Oop.Infrastructure
{
    public class ApplicationResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; private set; }
        public Enums.ErrorCode ErrorCode { get; private set; }

        protected ApplicationResult(Enums.ErrorCode errorCode)
        {
            IsSuccess = false;
            Message = TranslateErrorCode(errorCode);
            ErrorCode = errorCode;
        }

        protected ApplicationResult()
        {
            IsSuccess = true;
        }

        protected ApplicationResult(string message)
        {
            IsSuccess = true;
            Message = message;
        }

        protected ApplicationResult(Enums.ErrorCode errorCode, string errorMessage)
        {
            IsSuccess = false;
            Message = errorMessage;
            ErrorCode = errorCode;
        }

        protected ApplicationResult(Enums.SuccessCode successCode)
        {
            IsSuccess = true;
            Message = TranslateSuccessCode(successCode);
        }

        public static ApplicationResult Fail(Enums.ErrorCode errorCode)
        {
            return new ApplicationResult(errorCode);
        }

        public static ApplicationResult Fail(Enums.ErrorCode errorCode, params object[] args)
        {
            var newArs = args.Select(x => (object)ResourceManagerHelper.FindValueInResources(x.ToString())).ToArray();
            return new ApplicationResult(errorCode, string.Format(TranslateErrorCode(errorCode), newArs));
        }

        public static ApplicationResult<T> Fail<T>(Enums.ErrorCode errorCode, params object[] args)
        {
            var newArs = args.Select(x => (object)ResourceManagerHelper.FindValueInResources(x.ToString())).ToArray();
            return new ApplicationResult<T>(default(T), errorCode, string.Format(TranslateErrorCode(errorCode), newArs));
        }

        public static ApplicationResult<T> Convert<T>(ApplicationResult source)
        {
            if (source.IsSuccess)
            {
                return new ApplicationResult<T>(default(T), source.Message);
            }

            return new ApplicationResult<T>(default(T), source.ErrorCode, source.Message);
        }

        public static ApplicationResult Ok()
        {
            return new ApplicationResult();
        }

        public static ApplicationResult Ok(Enums.SuccessCode message)
        {
            return new ApplicationResult(message);
        }

        public static ApplicationResult<T> Ok<T>() where T : class
        {
            return new ApplicationResult<T>(default(T));
        }

        public static ApplicationResult<T> Ok<T>(T value) where T : class
        {
            return new ApplicationResult<T>(value);
        }

        public static ApplicationResult<T> Ok<T>(T value, Enums.SuccessCode message) where T : class
        {
            return new ApplicationResult<T>(value, message);
        }

        private static string TranslateErrorCode(Enums.ErrorCode errorCode)
        {
            var resourceValue = ResourceManagerHelper.FindValueInResources(errorCode);
            if (!string.IsNullOrEmpty(resourceValue))
                return resourceValue;
            return errorCode.GetDescription();
        }

        private static string TranslateSuccessCode(Enums.SuccessCode successCode)
        {
            var resourceValue = ResourceManagerHelper.FindValueInResources(successCode);
            if (!string.IsNullOrEmpty(resourceValue))
                return resourceValue;
            return successCode.GetDescription();
        }
    }

    public class ApplicationResult<T> : ApplicationResult
    {
        public T Value { get; }

        protected internal ApplicationResult(T value, Enums.ErrorCode errorCode) : base(errorCode)
        {
            Value = value;
        }

        protected internal ApplicationResult(T value, Enums.ErrorCode errorCode, string errorMessage) : base(errorCode, errorMessage)
        {
            Value = value;
        }

        protected internal ApplicationResult(T value, Enums.SuccessCode success) : base(success)
        {
            Value = value;
        }

        protected internal ApplicationResult(T value) : base()
        {
            Value = value;
        }

        protected internal ApplicationResult(T value, string message) : base(message)
        {
            Value = value;
        }

    }
}
