export type TaskStatus = 0 | 1 | 2;

export interface TaskItem {
  id: string;
  title: string;
  description?: string;
  status: TaskStatus;
  createdAt: string;
  updatedAt: string;
  isDeleted: boolean;
}

export const TaskStatusLabels = {
  0: 'Todo',
  1: 'InProgress',
  2: 'Done',
} as const;
