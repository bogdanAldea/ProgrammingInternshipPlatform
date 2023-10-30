export interface Account {
    coordinatorId: string;
    displayName: string;
    givenName: string;
    surname: string;
    initials: string;
    jobTitle: string;
    email: string;
    shortenedEmail: string;
    role: string;
}

export interface AccountWithPicture extends Account {
    pictureUrl?: string;
}