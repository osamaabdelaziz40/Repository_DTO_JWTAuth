namespace PRJ.Utility
{
    public static class Output
    {
        public static OutputDTO<T> Handler<T>(int outputCode, T data)
        {
            var output = new OutputDTO<T>
            {
                Data = data,
            };

            switch (outputCode)
            {
                case ResponseMessagesCode.ADD:
                    output.Message = ResponseMessages.ADD;
                    break;

                case ResponseMessagesCode.BAD_REQUEST:
                    output.Message = ResponseMessages.BAD_REQUEST;
                    output.Succeeded = false;
                    break;

                case ResponseMessagesCode.BLOCKED:
                    output.Message = ResponseMessages.BLOCKED;
                    output.Succeeded = false;
                    break;

                case ResponseMessagesCode.DELETE:
                    output.Message = ResponseMessages.Deleted;
                    break;

                case ResponseMessagesCode.EXIST:
                    output.Message = ResponseMessages.EMAILEXIST;
                    output.Succeeded = false;
                    break;

                case ResponseMessagesCode.GET:
                    output.Message = ResponseMessages.GET;
                    break;

                case ResponseMessagesCode.INVALID_CREDENTIALS:
                    output.Message = ResponseMessages.INVALID_CREDENTIALS;
                    output.Succeeded = false;
                    break;

                case ResponseMessagesCode.NOT_FOUND:
                    output.Message = ResponseMessages.NOT_FOUND;
                    output.Succeeded = false;
                    break;

                case ResponseMessagesCode.UNAUTHORIZED:
                    output.Message = ResponseMessages.UNAUTHORIZED;
                    output.Succeeded = false;
                    break;

                case ResponseMessagesCode.UPDATE:
                    output.Message = ResponseMessages.UPDATE;
                    break;

                case ResponseMessagesCode.EMAILEXIST:
                    output.Message = ResponseMessages.EMAILEXIST;
                    output.Succeeded = false;
                    break;
            }

            return output;
        }
    }
}
