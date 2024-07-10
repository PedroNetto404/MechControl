using MechControl.Domain.Core.Primitives;

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
}