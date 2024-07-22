export const isNullOrEmpty: (value: string) => boolean = (value: string) => {
  const cleanedValue = value.trim();
  return cleanedValue === "" || cleanedValue === null || cleanedValue === undefined;
}