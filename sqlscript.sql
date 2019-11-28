
CREATE TABLE public.computer (
    id integer NOT NULL,
    name character varying(50),
    price integer,
    storagesize integer,
    storagetypeid integer,
    operatingsystemid integer,
    useid integer,
    batterycapacity integer,
    date_added date,
    time_added time without time zone
);

CREATE TABLE public.computeruse (
    idcomputeruse integer NOT NULL,
    use character varying
);

CREATE TABLE public.operatingsystem (
    idoperatingsystem integer NOT NULL,
    operating_system character varying
);

CREATE TABLE public.storagetype (
    idstoragetype integer NOT NULL,
    storagetype character varying(20)
);


INSERT INTO public.computer (id, name, price, storagesize, storagetypeid, operatingsystemid, useid, batterycapacity, date_added, time_added) VALUES (1, 'Lenovo Thinkpad t440p', 1399, 512, 2, 1, 1, 45, NULL, NULL);
INSERT INTO public.computer (id, name, price, storagesize, storagetypeid, operatingsystemid, useid, batterycapacity, date_added, time_added) VALUES (2, 'Lenovo Thinkpad t440p', 1399, 512, 2, 1, 1, 70, '2019-11-18', '16:03:14.118563');
INSERT INTO public.computer (id, name, price, storagesize, storagetypeid, operatingsystemid, useid, batterycapacity, date_added, time_added) VALUES (3, 'AppleMacbook', 1699, 256, 2, 2, 1, 50, '2019-11-20', '16:45:32.586564');
INSERT INTO public.computer (id, name, price, storagesize, storagetypeid, operatingsystemid, useid, batterycapacity, date_added, time_added) VALUES (4, 'asd', 99, 123, 2, 2, 2, 22, NULL, NULL);
INSERT INTO public.computer (id, name, price, storagesize, storagetypeid, operatingsystemid, useid, batterycapacity, date_added, time_added) VALUES (5, 'Asus kk123', 999, 512, 3, 1, 2, 0, NULL, NULL);
INSERT INTO public.computer (id, name, price, storagesize, storagetypeid, operatingsystemid, useid, batterycapacity, date_added, time_added) VALUES (6, 'HP kk333', 1540, 512, 2, 1, 3, 0, NULL, NULL);
INSERT INTO public.computer (id, name, price, storagesize, storagetypeid, operatingsystemid, useid, batterycapacity, date_added, time_added) VALUES (7, 'Asus oo123', 999, 512, 1, 1, 1, 0, '2019-11-26', '16:18:38.134807');


INSERT INTO public.computeruse (idcomputeruse, use) VALUES (1, 'business');
INSERT INTO public.computeruse (idcomputeruse, use) VALUES (2, 'editing');
INSERT INTO public.computeruse (idcomputeruse, use) VALUES (3, 'basic');
INSERT INTO public.computeruse (idcomputeruse, use) VALUES (4, 'gaming');

INSERT INTO public.operatingsystem (idoperatingsystem, operating_system) VALUES (1, 'windows');
INSERT INTO public.operatingsystem (idoperatingsystem, operating_system) VALUES (2, 'ios');
INSERT INTO public.operatingsystem (idoperatingsystem, operating_system) VALUES (3, 'else');

INSERT INTO public.storagetype (idstoragetype, storagetype) VALUES (1, 'hdd');
INSERT INTO public.storagetype (idstoragetype, storagetype) VALUES (2, 'ssd');
INSERT INTO public.storagetype (idstoragetype, storagetype) VALUES (3, 'm2_ssd');

ALTER TABLE ONLY public.computer
    ADD CONSTRAINT "Computer_pkey" PRIMARY KEY (id);

ALTER TABLE ONLY public.computeruse
    ADD CONSTRAINT "Computeruse_pkey" PRIMARY KEY (idcomputeruse);

ALTER TABLE ONLY public.operatingsystem
    ADD CONSTRAINT "Operatingsystem_pkey" PRIMARY KEY (idoperatingsystem);

ALTER TABLE ONLY public.storagetype
    ADD CONSTRAINT "Storagetype_pkey" PRIMARY KEY (idstoragetype);

ALTER TABLE ONLY public.computer
    ADD CONSTRAINT operatingsystemfk FOREIGN KEY (operatingsystemid) REFERENCES public.operatingsystem(idoperatingsystem) NOT VALID;

ALTER TABLE ONLY public.computer
    ADD CONSTRAINT storagetypefk FOREIGN KEY (storagetypeid) REFERENCES public.storagetype(idstoragetype) NOT VALID;

ALTER TABLE ONLY public.computer
    ADD CONSTRAINT usefk FOREIGN KEY (useid) REFERENCES public.computeruse(idcomputeruse) NOT VALID;

