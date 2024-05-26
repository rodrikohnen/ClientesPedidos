using System.ComponentModel.DataAnnotations;

namespace Clientes.Models;
public class DocumentoAttribute : ValidationAttribute
{
    private readonly string[] _documentosValidos;

    public DocumentoAttribute(params string[] documentosValidos)
    {
        _documentosValidos = documentosValidos;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var documento = value as string;

        if (documento == null || !_documentosValidos.Contains(documento.ToLower()))
        {
            return new ValidationResult($"El tipo de documento debe ser uno de los siguientes: {string.Join(", ", _documentosValidos)}");
        }

        return ValidationResult.Success!;
    }
}