import { Dispatch } from 'react';


export type AnyStringFilterOption = {
    label: string,
    filter: Dispatch<any>
}

export type SelectStringFilterOption = {
    label: string,
    selectValues: string[],
    setFilter: Dispatch<any>
}

type Props = {
    className?: string,
    anyStringFilters: AnyStringFilterOption[]
    selectStringFilters: SelectStringFilterOption[]
}

