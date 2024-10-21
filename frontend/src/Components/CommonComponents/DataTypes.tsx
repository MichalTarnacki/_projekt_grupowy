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

export type CruiseEffectData = {
    id: string,
    points: string,
    researchTask: ResearchTask
}

export type ResearchTask = {
    type: string,
    title: string,
    authors: string,
    institution: string,
    date: string,
    financingAmount: string,
    description: string,
    done: string,

}