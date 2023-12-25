using PaySpace.Tax.Application.Services.Interfaces;
using PaySpace.Tax.Infrastructure.Enums;
using System.Collections.Immutable;
using System.Reflection;

namespace PaySpace.Tax.Application.Services
{
    public sealed class TaxCalculationServiceFactory : ITaxCalculationServiceFactory
    {
        private readonly IReadOnlyDictionary<TaxType, ITaxCalculationService> _taxCalculationServices;

        public TaxCalculationServiceFactory()
        {
            Type providerType = typeof(ITaxCalculationService);

            _taxCalculationServices = Assembly.GetExecutingAssembly().GetTypes()
                                     .Where(x => x.GetInterfaces().Contains(providerType) && x.IsAssignableFrom(x) && !      x.IsInterface && !x.IsAbstract)
                                     .Select(x => Activator.CreateInstance(x)).Cast<ITaxCalculationService>()
                                     .ToImmutableDictionary(x => x.TaxType, x => x);
        }

        /// <summary>
        /// Returns an Instance of <see cref="ITaxCalculationService"/> that matches <paramref name="taxType"/>
        /// </summary>
        /// <param name="taxType"></param>
        /// <exception cref="KeyNotFoundException">is thrown when postal code is not found or invalid.</exception>
        /// <returns>An instance of  <see cref="ITaxCalculationService"/> that matches the postal code provided</returns>
        public ITaxCalculationService GetTaxCalculationService(TaxType taxType)
        {
            return _taxCalculationServices[taxType];
        }
    }
}
