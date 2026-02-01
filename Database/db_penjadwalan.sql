/*
 Navicat Premium Dump SQL

 Source Server         : DBEngine
 Source Server Type    : MySQL
 Source Server Version : 80402 (8.4.2)
 Source Host           : localhost:3310
 Source Schema         : db_penjadwalan

 Target Server Type    : MySQL
 Target Server Version : 80402 (8.4.2)
 File Encoding         : 65001

 Date: 01/02/2026 14:03:00
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for tbl_dosen
-- ----------------------------
DROP TABLE IF EXISTS `tbl_dosen`;
CREATE TABLE `tbl_dosen`  (
  `kd_dosen` varchar(6) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `kd_prodi` varchar(5) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `nidn_dosen` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `nama_dosen` varchar(120) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `jk_dosen` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `no_telp_dosen` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `email_dosen` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`kd_dosen` DESC) USING BTREE,
  UNIQUE INDEX `uq_nidn_dosen`(`nidn_dosen` ASC) USING BTREE,
  UNIQUE INDEX `uq_nama_dosen`(`nama_dosen` ASC) USING BTREE,
  UNIQUE INDEX `uq_no_telp_dosen`(`no_telp_dosen` ASC) USING BTREE,
  UNIQUE INDEX `uq_email_dosen`(`email_dosen` ASC) USING BTREE,
  INDEX `fk_dosen_prodi`(`kd_prodi` ASC) USING BTREE,
  CONSTRAINT `fk_dosen_prodi` FOREIGN KEY (`kd_prodi`) REFERENCES `tbl_prodi` (`kd_prodi`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tbl_dosen
-- ----------------------------

-- ----------------------------
-- Table structure for tbl_dosen_pengampu_matkul
-- ----------------------------
DROP TABLE IF EXISTS `tbl_dosen_pengampu_matkul`;
CREATE TABLE `tbl_dosen_pengampu_matkul`  (
  `kd_pengampu` varchar(7) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `kd_dosen` varchar(6) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `kd_matkul` varchar(7) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `nama_kelas` varchar(120) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `tahun_akademik` varchar(11) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`kd_pengampu` DESC) USING BTREE,
  INDEX `fk_pengampu_dosen`(`kd_dosen` ASC) USING BTREE,
  INDEX `fk_pengampu_matkul`(`kd_matkul` ASC) USING BTREE,
  CONSTRAINT `fk_pengampu_dosen` FOREIGN KEY (`kd_dosen`) REFERENCES `tbl_dosen` (`kd_dosen`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_pengampu_matkul` FOREIGN KEY (`kd_matkul`) REFERENCES `tbl_matakuliah` (`kd_matkul`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tbl_dosen_pengampu_matkul
-- ----------------------------

-- ----------------------------
-- Table structure for tbl_hari
-- ----------------------------
DROP TABLE IF EXISTS `tbl_hari`;
CREATE TABLE `tbl_hari`  (
  `id_hari` varchar(5) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `nama_hari` varchar(120) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`id_hari`) USING BTREE,
  UNIQUE INDEX `uq_nama_hari`(`nama_hari` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tbl_hari
-- ----------------------------
INSERT INTO `tbl_hari` VALUES ('HR005', 'JUMAT');
INSERT INTO `tbl_hari` VALUES ('HR004', 'KAMIS');
INSERT INTO `tbl_hari` VALUES ('HR003', 'RABU');
INSERT INTO `tbl_hari` VALUES ('HR002', 'SELASA');
INSERT INTO `tbl_hari` VALUES ('HR001', 'SENIN');

-- ----------------------------
-- Table structure for tbl_jadwal_matkul
-- ----------------------------
DROP TABLE IF EXISTS `tbl_jadwal_matkul`;
CREATE TABLE `tbl_jadwal_matkul`  (
  `kd_pengampu` varchar(7) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `id_hari` varchar(5) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `jam_awal` time NOT NULL,
  `jam_akhir` time NOT NULL,
  `kd_ruangan` varchar(5) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`kd_pengampu`) USING BTREE,
  INDEX `idx_bentrok_ruangan`(`id_hari` ASC, `jam_awal` ASC, `jam_akhir` ASC, `kd_ruangan` ASC) USING BTREE COMMENT 'cek bentrok ruangan di hari tertentu',
  INDEX `idx_jadwal_pengampu`(`kd_pengampu` ASC, `id_hari` ASC, `jam_awal` ASC) USING BTREE,
  INDEX `fk_jadwal_ruangan`(`kd_ruangan` ASC) USING BTREE,
  CONSTRAINT `fk_jadwal_hari` FOREIGN KEY (`id_hari`) REFERENCES `tbl_hari` (`id_hari`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_jadwal_pengampu` FOREIGN KEY (`kd_pengampu`) REFERENCES `tbl_dosen_pengampu_matkul` (`kd_pengampu`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_jadwal_ruangan` FOREIGN KEY (`kd_ruangan`) REFERENCES `tbl_ruangkelas` (`kd_ruangan`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tbl_jadwal_matkul
-- ----------------------------

-- ----------------------------
-- Table structure for tbl_matakuliah
-- ----------------------------
DROP TABLE IF EXISTS `tbl_matakuliah`;
CREATE TABLE `tbl_matakuliah`  (
  `kd_matkul` varchar(7) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `nama_matkul` varchar(120) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `sks_matkul` int NOT NULL,
  `teori_matkul` int NOT NULL,
  `praktek_matkul` int NOT NULL,
  `semester_matkul` int NOT NULL,
  `kd_prodi` varchar(7) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`kd_matkul` DESC) USING BTREE,
  UNIQUE INDEX `uq_nama_matkul`(`nama_matkul` ASC) USING BTREE,
  INDEX `fk_matkul_prodi`(`kd_prodi` ASC) USING BTREE,
  CONSTRAINT `fk_matkul_prodi` FOREIGN KEY (`kd_prodi`) REFERENCES `tbl_prodi` (`kd_prodi`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tbl_matakuliah
-- ----------------------------

-- ----------------------------
-- Table structure for tbl_prodi
-- ----------------------------
DROP TABLE IF EXISTS `tbl_prodi`;
CREATE TABLE `tbl_prodi`  (
  `kd_prodi` varchar(5) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `nama_prodi` varchar(120) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`kd_prodi` DESC) USING BTREE,
  UNIQUE INDEX `uq_nama_prodi`(`nama_prodi` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tbl_prodi
-- ----------------------------

-- ----------------------------
-- Table structure for tbl_ruangkelas
-- ----------------------------
DROP TABLE IF EXISTS `tbl_ruangkelas`;
CREATE TABLE `tbl_ruangkelas`  (
  `kd_ruangan` varchar(5) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `nama_ruangan` varchar(120) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `kapasitas` int NOT NULL,
  PRIMARY KEY (`kd_ruangan` DESC) USING BTREE,
  UNIQUE INDEX `uq_nama_ruangan`(`nama_ruangan` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tbl_ruangkelas
-- ----------------------------

-- ----------------------------
-- Table structure for tbl_user
-- ----------------------------
DROP TABLE IF EXISTS `tbl_user`;
CREATE TABLE `tbl_user`  (
  `id_user` varchar(8) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'Akun Login',
  `nama_user` varchar(120) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `pass_user` char(6) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `level_user` varchar(80) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`id_user` DESC) USING BTREE,
  UNIQUE INDEX `uq_nama_user`(`nama_user` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tbl_user
-- ----------------------------
INSERT INTO `tbl_user` VALUES ('001', 'Admin', '@123', 'Administrator');

-- ----------------------------
-- View structure for vw_jadwal_cetak
-- ----------------------------
DROP VIEW IF EXISTS `vw_jadwal_cetak`;
CREATE ALGORITHM = UNDEFINED SQL SECURITY DEFINER VIEW `vw_jadwal_cetak` AS select `j`.`kd_pengampu` AS `kd_pengampu`,`d`.`tahun_akademik` AS `tahun_akademik`,`d`.`nama_kelas` AS `jenis_kelas`,`m`.`nama_matkul` AS `nama_matkul`,`m`.`kd_matkul` AS `kd_matkul`,`dos`.`nidn_dosen` AS `nidn`,`dos`.`nama_dosen` AS `nama_dosen`,`h`.`nama_hari` AS `nama_hari`,`j`.`jam_awal` AS `jam_mulai`,`j`.`jam_akhir` AS `jam_selesai`,`r`.`kd_ruangan` AS `kd_ruangan`,`r`.`nama_ruangan` AS `nama_ruangan`,`p`.`nama_prodi` AS `nama_prodi`,`m`.`semester_matkul` AS `semester`,`m`.`sks_matkul` AS `sks` from ((((((`tbl_jadwal_matkul` `j` join `tbl_dosen_pengampu_matkul` `d` on((`j`.`kd_pengampu` = `d`.`kd_pengampu`))) join `tbl_matakuliah` `m` on((`d`.`kd_matkul` = `m`.`kd_matkul`))) join `tbl_dosen` `dos` on((`d`.`kd_dosen` = `dos`.`kd_dosen`))) join `tbl_hari` `h` on((`j`.`id_hari` = `h`.`id_hari`))) join `tbl_ruangkelas` `r` on((`j`.`kd_ruangan` = `r`.`kd_ruangan`))) join `tbl_prodi` `p` on((`m`.`kd_prodi` = `p`.`kd_prodi`)));

-- ----------------------------
-- View structure for vw_plotting_dosen
-- ----------------------------
DROP VIEW IF EXISTS `vw_plotting_dosen`;
CREATE ALGORITHM = UNDEFINED SQL SECURITY DEFINER VIEW `vw_plotting_dosen` AS select `p`.`nama_prodi` AS `nama_prodi`,`d`.`kd_dosen` AS `kd_dosen`,`d`.`nidn_dosen` AS `nidn_dosen`,`d`.`nama_dosen` AS `nama_dosen`,`pm`.`tahun_akademik` AS `tahun_akademik`,NULL AS `semester_akademik`,`m`.`kd_matkul` AS `kd_matkul`,`m`.`nama_matkul` AS `nama_matkul`,`m`.`sks_matkul` AS `sks_total`,`m`.`teori_matkul` AS `sks_teori`,`m`.`praktek_matkul` AS `sks_praktek`,`m`.`semester_matkul` AS `semester_matkul`,`pm`.`nama_kelas` AS `jenis_kelas` from (((`tbl_dosen_pengampu_matkul` `pm` join `tbl_dosen` `d` on((`pm`.`kd_dosen` = `d`.`kd_dosen`))) join `tbl_matakuliah` `m` on((`pm`.`kd_matkul` = `m`.`kd_matkul`))) join `tbl_prodi` `p` on((`d`.`kd_prodi` = `p`.`kd_prodi`)));

SET FOREIGN_KEY_CHECKS = 1;
