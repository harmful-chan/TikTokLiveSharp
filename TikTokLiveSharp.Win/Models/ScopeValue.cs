using System;
using System.Collections.Generic;
using System.Text;

namespace TikTokLiveSharp.Win.Models
{
    public class ScopeValue<T> where T : unmanaged, IComparable
    {
        public ScopeValue(T minimum, T maximum, T value)
        {
            this._maximum = maximum;
            this._minimum = minimum;
            _value = value;
        }

        private T _maximum;

        public T Maximum => _maximum;

        private T _minimum;

        public T Minimum => _minimum;

        private T _value;
        public T Value
        {
            get { return _value; }
            set
            {
                if (Meet(value))
                {
                    _value = value;
                }
                //else
                //{
                //    throw new OverflowException($"value: {value}, must be >= {_minimum} and <= {_maximum}");
                //}
            }
        }


        public bool Meet(T i)
        {
            int a = i.CompareTo(this.Minimum);
            int b = Maximum.CompareTo(i);
            return   a >= 0 && b >= 0;
        }
    }
}
