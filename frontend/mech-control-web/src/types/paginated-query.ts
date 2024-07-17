export abstract class PaginatedQuery {
  fetch: number;
  offset: number;
  sortBy: string;
  sortOrder: string;

  constructor(
    fetch: number = 10,
    offset: number = 0,
    sortBy: string = "id",
    sortOrder: string = "asc",
  ) {
    this.sortBy = sortBy;
    this.sortOrder = sortOrder;
    this.fetch = fetch;
    this.offset = offset;

    if (!fetch || fetch < 1) {
      this.fetch = 1;
    }

    if (!offset || offset < 1) {
      this.offset = 10;
    }

    if (!sortOrder || !["asc", "desc"].includes(sortOrder)) {
      this.sortOrder = "asc";
    }

    const allowValuesForSortBy = this.getAllowValues();
    if (
      allowValuesForSortBy.length > 0 &&
      !allowValuesForSortBy.includes(sortBy)
    ) {
      this.sortBy = allowValuesForSortBy[0];
    }
  }

  protected abstract getAllowValues(): string[];
}
