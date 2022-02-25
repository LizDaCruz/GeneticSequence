namespace ProteinTranslation.Core
{
    public enum CodonType
    {
        // Codes for an amino acid
        Coding,

        // Indicates the start of a protein, if one is not already being coded for. Otherwise it
        // codes for an amino acid.
        StartOrCoding,

        // Indicates the end of a protein.
        Stop,
    }
}
