export interface Navigation<T> {
  previousId: number | null;
  nextId: number | null;
  data: T;
}