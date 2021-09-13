using Newtonsoft.Json;

namespace BlogEngine.Security.API.Models
{
    public class ResponseEntity<T>
    {
        public ResponseEntity()
        {

        }
        public int code { get; set; } = 200;
        public bool status { get; set; } = true;
        public string message { get; set; } = null;
        public string messageException { get; set; } = null;
        public T result { get; set; }

        public static ResponseEntity<T> Create(T result)
        {
            return new ResponseEntity<T> { result = result };
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
