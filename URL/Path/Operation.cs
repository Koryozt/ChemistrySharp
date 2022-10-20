namespace ChemistrySharp.URL.Path
{
    public enum Operations
    {
        record,
        synonyms,
        sids,
        cids,
        aids,
        assaysummary,
        classification,
        description,
        conformers,
        property,
        xrefs,
        concise,
        targets,
        pwaccs,
        accessions
    }
    // Only if you will use targets operation.

    public enum TargetTypes
    {
        ProteinGI,
        ProteinName,
        GeneID,
        GeneSymbol
    }
}