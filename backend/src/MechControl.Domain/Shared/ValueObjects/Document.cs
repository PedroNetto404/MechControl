using MechControl.Domain.Core.Primitives;
using MechControl.Domain.Core.Primitives.Result;
using MechControl.Domain.Features.Customers.Enums;

namespace MechControl.Domain.Shared.ValueObjects;

public abstract class Document : ValueObject<Document>
{
	public string Value { get; }

    protected Document(string value) => Value = value;

    protected override IEnumerable<object> GetEqualityComponents()
	{
		yield return Value;
	}

    public static Result<Document> New(CustomerType customerType, string document) =>
        customerType switch

        {
            CustomerType.Corporate => Cnpj.New(document),
            CustomerType.Individual => Cpf.New(document),
            _ => throw new InvalidOperationException("Invalid customer type")

        };
    
    public static implicit operator string(Document document) => document.Value;	
}
