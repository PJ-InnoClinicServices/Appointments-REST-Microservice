CREATE TABLE "Appointments" (
                                "Id" uuid PRIMARY KEY,
                                "AppointmentDate" timestamp with time zone NOT NULL,
                                "Reason" text NOT NULL,
                                "Status" integer NOT NULL,
                                "PatientId" uuid NOT NULL,
                                "DoctorId" uuid NOT NULL,
                                "PlaceId" uuid NOT NULL
);