export interface UserData {
    roles: string[]
    firstName: string,
    lastName: string,
    accepted: boolean,
    email: string,
    emailConfirmed: boolean,
    id: string
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
    userId: string,
    points: string,
    effect: ResearchTask
}

export type ResearchTask = {
    type: string,
    title?: string,
    magazine?: string,
    author?: string,
    institution?: string,
    date?: string,
    name?: string,
    startDate?: string,
    endDate?: string,
    financingApproved?: string
    financingAmount?: string,
    description?: string
    securedAmount?: string,
    ministerialPoints?: string
}