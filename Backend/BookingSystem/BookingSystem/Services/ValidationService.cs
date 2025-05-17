namespace BookingSystem.Services
{
    public class ValidationService
    {
        public static bool isEmptyDTO(object dto)
        {
            foreach (var prop in dto.GetType().GetProperties())
            {
                var value = prop.GetValue(dto);
                if(Nullable.GetUnderlyingType(prop.PropertyType) == null){
                    if (value == null) 
                        return true;
                }
            }
            return false;
        }
    }
}
