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