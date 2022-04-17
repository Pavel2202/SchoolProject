namespace Warehouse.Data
{
    public static class DataConstants
    {
        public const int UserNameMinLength = 5;
        public const int UserNameMaxLength = 40;
        public const int UserPasswordMinLength = 5;
        public const int UserPasswordMaxLength = 25;

        public const int ProductNameMinLength = 3;
        public const int ProductNameMaxLength = 50;
        public const double ProductQuantityMinValue = 1;
        public const double ProductQuantityMaxValue = 100000;
        public const double ProductUnitPriceMinValue = 0.20;
        public const double ProductUnitPriceMaxValue = 100000;
        public const int ProductSupplierMinLength = 5;
        public const int ProductSupplierMaxLength = 50;
    }
}
