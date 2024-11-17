import Papa from "papaparse";

// @ts-ignore
const PublicationImporter = ({onSavePublications}) => {

    const handleFileChange = (e: any) => {
        const file = e.target.files[0];
        if (file) {
            handleFileUpload(file);
            e.target.value = null;
        }
    };

    const handleFileUpload = (file: any) => {
        if (!file) return;

        const reader = new FileReader();
        reader.onload = (e) => {
            const decoder = new TextDecoder("windows-1250");
            // @ts-ignore
            const csvText = decoder.decode(e.target.result);

            Papa.parse(csvText, {
                delimiter: ";",
                header: true,
                skipEmptyLines: true,
                complete: (results: any) => {
                    // @ts-ignore
                    const publications = results.data.map(row => ({
                        category: "subject",
                        doi: row["Numer DOI"],
                        authors: row["Autorzy"],
                        title: row["Tytuł publikacji"],
                        magazine: row["Nazwa czasopisma"],
                        year: row["Rok"],
                        ministerialPoints: row["Punkty"],
                    }));
                    onSavePublications(publications);
                },
            });
        };
        reader.readAsArrayBuffer(file);
    };

    return (
        <div className="d-flex flex-row flex-row-reverse">
            <input
                type="file"
                accept=".csv"
                onChange={handleFileChange}
                id="file-input"
                style={{display: 'none'}}
            />
            <label
                htmlFor="file-input"
                className="btn btn-primary fw-bold m-3"
            >
                Import publikacji z pliku CSV
            </label>
        </div>
    );
};

export default PublicationImporter;
