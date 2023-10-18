import { User } from './user';

export class Task {
    taskId: number;
    taskName: string;
    taskDescription: string;
    isComplete: boolean;
    userId: number;
    user: User;
}