export interface Pagination<TResonse> {
    totalItems: number;
    currentPage: number;
    totalPages: number;
    results: ReadonlyArray<TResonse>
}