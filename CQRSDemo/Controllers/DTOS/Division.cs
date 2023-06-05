namespace CQRSDemo.Controllers.DTOS
{
    public class Division
    {
        public float dividend { get; set; }
        public float divisor { get; set; }

        public float Divide(float dividend, float divisor)
        {
            return dividend / divisor;
        }

        
    }
}
