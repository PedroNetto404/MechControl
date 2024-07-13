export function calculateAge(birthDate: Date): Number {
    const today = new Date();
    const birthDateUtc = new Date(birthDate);
    let age = today.getFullYear() - birthDateUtc.getFullYear();
    const month = today.getMonth() - birthDateUtc.getMonth();
    if (month < 0 || (month === 0 && today.getDate() < birthDateUtc.getDate())) {
        age--;
    }
    return age;
}

export function formatBrDate(date: Date): string {
    return date.toLocaleDateString('pt-BR', {
        day: '2-digit',
        month: '2-digit',
        year: 'numeric',
    });
}
