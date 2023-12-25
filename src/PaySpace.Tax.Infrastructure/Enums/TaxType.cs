namespace PaySpace.Tax.Infrastructure.Enums
{
    /// <summary>
    /// Represents an enumeration of different tax types for use in tax calculations.
    /// </summary>
    public enum TaxType
    {
        /// <summary>
        /// Indicates a progressive tax type where the tax rate increases based on income brackets.
        /// </summary>
        Progessive,

        /// <summary>
        /// Indicates a flat value tax type where the tax is a fixed amount regardless of income.
        /// </summary>
        FlatValue,

        /// <summary>
        /// Indicates a flat rate tax type where the tax is calculated as a fixed percentage of the income.
        /// </summary>
        FlatRate
    }
}
