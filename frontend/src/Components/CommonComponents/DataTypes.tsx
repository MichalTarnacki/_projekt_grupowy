export type UserData  = {
    roles: string[],
    firstName: string,
    lastName: string,
    accepted: boolean,
    email: string,
    emailConfirmed: boolean,
    id:string
}

export type PublicationData = {
    category: string,
    doi: string,
    authors: string,
    title: string,
    magazine: string,
    year: string,
    ministerialPoints: string,
    id: string,
}