-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 28, 2025 at 04:11 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `lostandfoundv`
--

-- --------------------------------------------------------

--
-- Table structure for table `audit_logs`
--

CREATE TABLE `audit_logs` (
  `id` int(11) NOT NULL,
  `user_id` int(11) DEFAULT NULL,
  `action` varchar(255) DEFAULT NULL,
  `timestamp` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `categories`
--

CREATE TABLE `categories` (
  `id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `description` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `categories`
--

INSERT INTO `categories` (`id`, `name`, `description`) VALUES
(21, 'Phone', NULL),
(22, 'Wallet', NULL),
(23, 'Flash Drive', NULL),
(24, 'Keys', NULL),
(25, 'Laptop', NULL),
(26, 'Bag', NULL),
(27, 'ID', NULL),
(28, 'Jewelry', NULL),
(29, 'Clothing', NULL),
(30, 'Others', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `claims`
--

CREATE TABLE `claims` (
  `id` int(11) NOT NULL,
  `item_id` int(11) NOT NULL,
  `reporter_id` int(11) DEFAULT NULL,
  `claimant_name` varchar(255) NOT NULL,
  `claimant_contact` varchar(255) NOT NULL,
  `student_id` varchar(50) DEFAULT NULL,
  `year_level` varchar(50) DEFAULT NULL,
  `department` varchar(100) DEFAULT NULL,
  `claim_notes` text DEFAULT NULL,
  `claim_date` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `claims`
--

INSERT INTO `claims` (`id`, `item_id`, `reporter_id`, `claimant_name`, `claimant_contact`, `student_id`, `year_level`, `department`, `claim_notes`, `claim_date`) VALUES
(1, 1, NULL, 'Sample Data Claim', 'sampledata@gmail.com', NULL, NULL, NULL, 'This is my item', '2025-12-02 23:42:08'),
(2, 1, NULL, 'sample', 'sample', NULL, NULL, NULL, 'sample', '2025-12-02 23:49:58'),
(3, 1, NULL, 'New Request', 'request@gmail.com', NULL, NULL, NULL, 'test', '2025-12-02 23:57:00'),
(4, 3, NULL, 'John Doe', 'johndoe@gmail.com', NULL, NULL, NULL, 'I left this at cafeteria', '2025-12-03 06:23:13'),
(5, 12, NULL, 'John Doe', '09123123', '123123', '1st Year', 'HTM Department', NULL, '2025-12-11 23:59:51'),
(6, 12, NULL, 'John Doe', 'john Doe', '1231321', '1st Year', 'HTM Department', NULL, '2025-12-12 00:01:44'),
(7, 7, NULL, 'Second Person', '9012312', '123123', '2nd Year', 'IT Department', NULL, '2025-12-12 00:27:10'),
(8, 5, NULL, 'Sample', '9123912', '123123', '1st Year', 'HTM Department', NULL, '2025-12-12 13:24:22');

-- --------------------------------------------------------

--
-- Table structure for table `departments`
--

CREATE TABLE `departments` (
  `id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `description` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `departments`
--

INSERT INTO `departments` (`id`, `name`, `description`) VALUES
(1, 'IT Department', 'Information Technology'),
(2, 'HTM Department', 'Human Resources');

-- --------------------------------------------------------

--
-- Table structure for table `items`
--

CREATE TABLE `items` (
  `id` int(11) NOT NULL,
  `title` varchar(200) NOT NULL,
  `description` text DEFAULT NULL,
  `type` enum('Lost','Found') NOT NULL,
  `category_id` int(11) DEFAULT NULL,
  `location_id` int(11) DEFAULT NULL,
  `department_id` int(11) DEFAULT NULL,
  `status` enum('Pending','Approved','Claimed','Rejected','Claim Pending') DEFAULT 'Pending',
  `reporter_id` int(11) DEFAULT NULL,
  `student_name` varchar(200) DEFAULT NULL,
  `student_contact` varchar(150) DEFAULT NULL,
  `image_path` varchar(255) DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `items`
--

INSERT INTO `items` (`id`, `title`, `description`, `type`, `category_id`, `location_id`, `department_id`, `status`, `reporter_id`, `student_name`, `student_contact`, `image_path`, `created_at`, `updated_at`) VALUES
(1, 'Iphone12', 'black case with crack screen I lost it', 'Found', 21, 3, 1, 'Claimed', 5, '', '', 'uploads\\dacfdd71-ff11-48b8-bc60-56cafbd70ffd.jpg', '2025-12-02 15:40:07', '2025-12-08 08:36:51'),
(3, 'Bag', 'red bag left at cafeteria', 'Found', 26, 3, 1, 'Claimed', 5, NULL, NULL, 'uploads\\aa68e411-e1e3-49dc-8a12-2432e2e1c3f3.png', '2025-12-02 22:22:26', '2025-12-09 02:09:23'),
(4, 'iphone12', 'sample', 'Found', 21, 3, 1, 'Approved', 5, NULL, NULL, 'uploads\\0a444525-7561-45a2-8858-8bb851805399.jpg', '2025-12-03 01:06:53', '2025-12-08 08:36:51'),
(5, 'iphone12', 'black case', 'Found', 21, 3, 1, 'Claimed', 5, 'Sample', '09123124', 'uploads\\3fa78f25-4731-4dcc-8fe8-5fa03a315969.jpg', '2025-12-03 01:31:02', '2025-12-12 05:24:22'),
(6, 'test', 'test', 'Found', 29, 3, 1, 'Pending', 5, 'test', 'test', 'uploads\\f6df5c96-ca3c-49b6-bad7-ac02e38dc3ab.jpg', '2025-12-03 03:05:07', '2025-12-08 08:36:51'),
(7, 'test', 'test', 'Found', 23, 3, 1, 'Claimed', 5, 'test', 'test', NULL, '2025-12-08 03:18:57', '2025-12-11 16:27:10'),
(8, 'test', 'test', 'Found', 29, 3, 1, 'Pending', 5, NULL, NULL, NULL, '2025-12-08 03:36:38', '2025-12-08 08:36:51'),
(9, 'test', 'test', 'Found', 29, 3, NULL, 'Rejected', 5, NULL, NULL, 'uploads\\8d8cbd79-e257-40d8-8f78-a55faf0c63c6.jpg', '2025-12-08 04:46:26', '2025-12-11 16:11:11');

-- --------------------------------------------------------

--
-- Table structure for table `locations`
--

CREATE TABLE `locations` (
  `id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `description` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `locations`
--

INSERT INTO `locations` (`id`, `name`, `description`) VALUES
(1, 'Main Entrance', NULL),
(2, 'Library', NULL),
(3, 'Cafeteria', NULL),
(4, 'Auditorium', NULL),
(7, 'Test', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `role` enum('Staff','Admin','Super Admin') NOT NULL,
  `name` varchar(150) NOT NULL,
  `email` varchar(100) DEFAULT NULL,
  `IsActive` tinyint(1) NOT NULL DEFAULT 1,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `username`, `password`, `role`, `name`, `email`, `IsActive`, `created_at`, `updated_at`) VALUES
(1, 'admin', '$2a$11$ehnkb3kZILGKs7RwV9jwJ.BPlp6VSdAtMOfxc8dw2s5l2jE/z0FQG', 'Admin', 'Admin Sample', 'adminsample@gmail.com', 1, '2025-10-25 13:35:55', '2025-11-30 04:02:32'),
(2, 'staff1', '[hashed_password_here]', 'Staff', '', NULL, 1, '2025-10-25 13:35:55', '2025-10-25 13:35:55'),
(5, 'staff', '$2a$11$JVee5N9nsq/2FMdGNdp1euS.pdrKOGXXMOLQ2i4/F82b4EJBBp9tm', 'Staff', 'Staff User', 'staff@example.com', 1, '2025-11-21 13:29:49', '2025-11-21 13:46:04'),
(6, 'superadmin', '$2a$11$P2.zuo6tbfV14QT3R/aKkeXXTTUBcYYUqiA3O7as4Bh2oko2klPfy', 'Super Admin', 'SuperAdmin', 'superadmin@example.com', 1, '2025-11-21 14:18:57', '2025-11-30 06:04:07'),
(7, 'sampleusername', '$2a$11$vueV.RVVjkvX0l.Iaxt4CuVpVf8pqk.rJyACO6HU8M/EYbbT/qLDa', 'Staff', 'Sample Name', 'samplename@gmail.com', 1, '2025-11-25 16:20:55', '2025-11-25 16:20:55'),
(8, 'sample', '$2a$11$RkQACIX.8h2HLdrqQ/8cWOYiJx92UshMz8VyPAZ1bxehZriScT2d2', 'Staff', 'sample', 'sample', 1, '2025-11-25 16:24:08', '2025-11-29 09:29:35'),
(11, 'samplestaff', '$2a$11$J9MikmeqBnMP7A/AHLtQxuSSaB5qd09zbZlwA49rlLv3Z56.xpgcW', 'Staff', 'Sample Staff', 'samplestaff@gmail.com', 1, '2025-11-30 04:03:21', '2025-11-30 04:03:21');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `audit_logs`
--
ALTER TABLE `audit_logs`
  ADD PRIMARY KEY (`id`),
  ADD KEY `user_id` (`user_id`);

--
-- Indexes for table `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `name` (`name`);

--
-- Indexes for table `claims`
--
ALTER TABLE `claims`
  ADD PRIMARY KEY (`id`),
  ADD KEY `item_id` (`item_id`),
  ADD KEY `claims_ibfk_2` (`reporter_id`);

--
-- Indexes for table `departments`
--
ALTER TABLE `departments`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `name` (`name`);

--
-- Indexes for table `items`
--
ALTER TABLE `items`
  ADD PRIMARY KEY (`id`),
  ADD KEY `category_id` (`category_id`),
  ADD KEY `location_id` (`location_id`),
  ADD KEY `reporter_id` (`reporter_id`),
  ADD KEY `department_id` (`department_id`);

--
-- Indexes for table `locations`
--
ALTER TABLE `locations`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `name` (`name`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `audit_logs`
--
ALTER TABLE `audit_logs`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `categories`
--
ALTER TABLE `categories`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- AUTO_INCREMENT for table `claims`
--
ALTER TABLE `claims`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `departments`
--
ALTER TABLE `departments`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `items`
--
ALTER TABLE `items`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `locations`
--
ALTER TABLE `locations`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `audit_logs`
--
ALTER TABLE `audit_logs`
  ADD CONSTRAINT `audit_logs_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);

--
-- Constraints for table `claims`
--
ALTER TABLE `claims`
  ADD CONSTRAINT `claims_ibfk_2` FOREIGN KEY (`reporter_id`) REFERENCES `users` (`id`) ON DELETE SET NULL;

--
-- Constraints for table `items`
--
ALTER TABLE `items`
  ADD CONSTRAINT `items_ibfk_1` FOREIGN KEY (`category_id`) REFERENCES `categories` (`id`) ON DELETE SET NULL,
  ADD CONSTRAINT `items_ibfk_2` FOREIGN KEY (`location_id`) REFERENCES `locations` (`id`),
  ADD CONSTRAINT `items_ibfk_3` FOREIGN KEY (`reporter_id`) REFERENCES `users` (`id`),
  ADD CONSTRAINT `items_ibfk_4` FOREIGN KEY (`department_id`) REFERENCES `departments` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
