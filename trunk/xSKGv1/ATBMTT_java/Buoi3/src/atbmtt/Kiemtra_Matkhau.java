package atbmtt;

import java.io.BufferedReader;
import java.io.FileReader;
import java.util.Scanner;

public class Kiemtra_Matkhau {
	public static void main(String[] args) {
		try {
			// Nhập mật khẩu
			Scanner userIn = new Scanner(System.in);
			System.out.print("Mật khẩu: ");
			String msg = userIn.nextLine();
			userIn.close();

			// Tạo MD5 từ chuỗi, lưu vào file
			String md5 = FileHasher.CreateStringMD5(msg);

			// Đọc file password.txt
			BufferedReader reader = new BufferedReader(new FileReader(
					"c:\\password.txt"));
			String pass = reader.readLine();
			reader.close();

			// So sánh 2 chuỗi MD5
			int ok = md5.compareTo(pass);
			if (ok == 0)
				System.out.print("Mat khau dung");
			else
				System.out.print("Mat khau sai");

		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
