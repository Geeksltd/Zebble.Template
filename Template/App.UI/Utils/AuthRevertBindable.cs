namespace UI.Utils
{
    using System;
    using System.Threading.Tasks;
    using Zebble;

    class AuthRevertBindable<T> : Bindable<T>
    {
        public AuthRevertBindable(T value) : base(value)
        {
        }

        public virtual async Task<IDisposable> SetAsync(T value)
        {
            var originValue = Value;

            Set(value);

            return new BindableRestorer<T>(this, originValue);
        }
    }

    class BindableRestorer<T> : IDisposable
    {
        private readonly Bindable<T> _source;
        private readonly T _originValue;

        public BindableRestorer(Bindable<T> source, T originValue)
        {
            _source = source;
            _originValue = originValue;
        }

        public void Dispose() => _source.Set(_originValue);
    }
}
