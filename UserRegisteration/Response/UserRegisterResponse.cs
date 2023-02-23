namespace UserRegisteration.Response
{
    public class UserRegisterResponse<T>
    {

        public T Data { get; set; }


        public UserRegisterResponse(T data)
        {
            this.Data = data;
        }
    }
}
