namespace ChemistrySharp.URL
{
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

	public enum Namespaces
	{
		aid,
		sid,
		sourceid,
		sourceall,
		cid,
		name,
		smiles,
		inchi,
		sdf,
		type,
		target,
		activity,
		inchikey,
		formula,
		listkey
	}

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
		invitro
	}
}