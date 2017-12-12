namespace Cosmetics.Contracts
{
    using Cosmetics.Common;

    public interface IShampoo : IProduct
    {
        uint Size { get; }

        UsageType Usage { get; }
    }
}