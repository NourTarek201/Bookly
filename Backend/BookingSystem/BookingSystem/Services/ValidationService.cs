namespace BookingSystem.services
{
    public class ValidationService
    {
        public static bool isEmptyDTO(object dto)
        {
            foreach (var prop in dto.GetType().GetProperties())
            {
                var value = prop.GetValue(dto);
                if (Nullable.GetUnderlyingType(prop.PropertyType) == null)
                {
                    if (value == null)
                        return true;
                    else if (value is string strValue && string.IsNullOrWhiteSpace(strValue))
                        return true;
                }
            }
            return false;
        }
    }
}
