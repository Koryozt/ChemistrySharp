namespace ChemistrySharp.URL.Path
{
    // Domain input specification. Required for any type of request.

    public enum Domain
    {
        substance,
        compound,
        assay,
        gene,
        protein,
        pathway,
        taxonomy,
        cell,
        sources,
        sourcetable,
        conformers,
        annotations,
        heading,
        classification
    }

    // Namespace from any input specification.
    // Some are only available for specific domains, if you try to use any namespace that is not part of its domain, you'll get an error.

    public enum Namespaces
    {
        cid,
        smiles,
        inchi,
        sdf,
        inchikey,
        formula,
        sid,
        sourceid,
        sourceall,
        aid,
        type,
        target,
        activity,
        geneid,
        genesymbol,
        synonym,
        accession,
        gi,
        pwacc,
        taxid,
        cellac,
        name,
        listkey,

    }

    // Compound domain namespaces.

    public enum StructureSearch
    {
        substructure,
        superstructure,
        similarity,
        identity
    }

    public enum FastSearch
    {
        fastidentity,
        fastsimilarity_2d,
        fastsimilarity_3d,
        fastsubstructure,
        fastsuperstructure
    }

    // Global domain namespace.

    public enum Xref
    {
        RegistriID,
        RN,
        PubMedID,
        MMDBID,
        ProteinGI,
        NucleotideGI,
        TaxonomyID,
        MIMID,
        GeneID,
        ProbeID,
        PatentID
    }

    // Assay domain namespaces.

    public enum AssayType
    {
        all,
        confirmatory,
        doseresponse,
        onhold,
        panel,
        rnai,
        screening,
        summary,
        cellbased,
        biochemical,
        invivo,
        invitro,
        activeconcentrationspecified
    }

    public enum AssayTarget
    {
        gi,
        proteinname,
        geneid,
        genesymbol,
        acession
    }

}