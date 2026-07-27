import { NarratorCriticismListResponse } from "./narrator-criticism-list-response";
import { NarratorStudentListResponse } from "./narrator-student-list-response";
import { NarratorTeacherListResponse } from "./narrator-teacher-list-response";



export interface NarratorDetailsResponse {
  id: number;
  number: number | null;
  name: string | null;
  gender: string | null;
  kunya: string | null;
  nickname: string | null;
  nasab: string | null;
  description: string | null;
  title: string | null;
  activity: string | null;
  madhhab: string | null;
  rank: string | null;
  layer: string | null;
  deathYear: string | null;
  birthYear: string | null;
  age: string | null;
  residence: string | null;
  deathPlace: string | null;
  relatives: string | null;
  mawali: string | null;
  narratedFor: string | null;
  kamal: string | null;
  sirAlamAlNubala: string | null;
  sifatAlSafwa: string | null;

  narratorStudents: NarratorStudentListResponse[];
  narratorTeachers: NarratorTeacherListResponse[];
  narratorsCriticisms: NarratorCriticismListResponse[];
}
