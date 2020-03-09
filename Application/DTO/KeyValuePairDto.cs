namespace Application.DTO
{
    public readonly struct KeyValuePairDto<TKey, TValue>
    {
        public KeyValuePairDto(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public TKey Key { get; }

        public TValue Value { get; }

        public override string ToString() 
            => $"Key : {Key} , Value : { Value}";
    }
    
}