namespace CleanArchMvc.Domain.Validation;

public class DomainExceptionValidation(string error) : Exception(error)
{
	public static void When(bool hasError, string errorMessage)
	{
		if (hasError)
			throw new DomainExceptionValidation(errorMessage);
	}
}