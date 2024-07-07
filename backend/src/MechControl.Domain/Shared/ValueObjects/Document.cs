using MechControl.Domain.Core.Primitives;
using MechControl.Domain.Core.Primitives.Result;

namespace MechControl.Domain.Shared.ValueObjects;

public abstract class Document : ValueObject<Document>
{
	public string Value { get; }

    protected Document(string value) => Value = value;

    public override IEnumerable<object> GetEqualityComponents()
	{
		yield return Value;
	}


	public static implicit operator string(Document document) => document.Value;	

	public override string ToString() => Value;

    public static Result<Document> New(string document) => document switch
	{
		_ when document.Trim().Length == Cpf.Length => Cpf.New(document),
		_ when document.Trim().Length == Cnpj.Length => Cnpj.New(document),
		_ => Result<Document>.Fail(new Error("invalid_document", "Invalid document"))
	};
}