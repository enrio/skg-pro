package baitap;

import java.io.*;
import java.security.interfaces.*;
import java.security.spec.*;
import java.security.*;
import java.util.*;

import javax.crypto.*;

public class Bt32 {
	private static void Taokhoa() {
		try {
			// Sinh ngẫu nhiên 1 cặp khoá
			KeyPairGenerator gen = KeyPairGenerator.getInstance("RSA");
			KeyPair key = gen.generateKeyPair();

			// Tạo khoá công khai kp, khoá bí mật ks
			RSAPublicKey kp = (RSAPublicKey) key.getPublic();
			RSAPrivateKey ks = (RSAPrivateKey) key.getPrivate();

			// Lưu trữ khoá công khai kp vào file kp.txt
			FileOutputStream fos = new FileOutputStream("c:\\kp.txt");
			fos.write(kp.getEncoded());
			fos.close();

			// Lưu trữ khoá bí mật ks vào file ks.txt
			fos = new FileOutputStream("c:\\ks.txt");
			fos.write(ks.getEncoded());
			fos.close();

			System.out.print("Tao cap khoa thanh cong!\n");

		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	// Mã hoá file với khoa công khai
	private static void Mahoa(String fileName_in, String fileName_out) {
		try {
			// Đọc khoá công khai
			FileInputStream fis = new FileInputStream("c:\\kp.txt");
			byte[] buff = new byte[fis.available()];
			fis.read(buff);
			fis.close();

			// Dựng khoá
			X509EncodedKeySpec spec = new X509EncodedKeySpec(buff);
			KeyFactory keyfac = KeyFactory.getInstance("RSA");
			RSAPublicKey kp = (RSAPublicKey) keyfac.generatePublic(spec);

			// Tạo và khởi động Si phơ với công khai kp
			Cipher cp = Cipher.getInstance("RSA");
			cp.init(Cipher.ENCRYPT_MODE, kp);

			// Đọc file chữ kí
			fis = new FileInputStream(fileName_in);
			FileOutputStream fos = new FileOutputStream(fileName_out);

			// Đọc dữ liệu từng khối, kích thước 117 bytes
			int size = 117;
			buff = new byte[size];

			while (true) {
				int n = fis.read(buff);
				if (n <= 0)
					break;
				byte[] cip = cp.doFinal(buff, 0, n);
				System.out.println("Size: " + cip.length);
				fos.write(cip);
			}
			fis.close();
			fos.close();

			System.out.print("Da ma hoa xong\n");

		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	// Giải mã file với khoa bí mật
	private static void Giaima(String fileName_in, String fileName_out) {
		try {
			// Đọc khoá công khai
			FileInputStream fis = new FileInputStream("c:\\ks.txt");
			byte[] buff = new byte[fis.available()];
			fis.read(buff);
			fis.close();

			// Dựng khoá
			PKCS8EncodedKeySpec spec = new PKCS8EncodedKeySpec(buff);
			KeyFactory keyfac = KeyFactory.getInstance("RSA");
			RSAPrivateKey ks = (RSAPrivateKey) keyfac.generatePrivate(spec);

			// Tạo và khởi động Si phơ với bí mật ks
			Cipher cp = Cipher.getInstance("RSA");
			cp.init(Cipher.DECRYPT_MODE, ks);

			// Đọc file chữ kí
			fis = new FileInputStream(fileName_in);
			FileOutputStream fos = new FileOutputStream(fileName_out);

			// Đọc dữ liệu từng khối, kích thước 128 bytes
			int size = 128;
			buff = new byte[size];

			while (true) {
				int n = fis.read(buff);
				if (n <= 0)
					break;
				byte[] cip = cp.doFinal(buff, 0, n);
				System.out.println("Size: " + cip.length);
				fos.write(cip);
			}
			fis.close();
			fos.close();

			System.out.print("Da giai ma xong\n");

		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	public static void main(String[] args) {
		try {

			// Mã hoá thông điệp đọc từ bàn phím
			Scanner userIn = new Scanner(System.in);
			System.out.print("Nhap ten file can ma hoa: ");
			String file_in = userIn.nextLine();
			System.out.print("Nhap ten file da ma hoa: ");
			String file_out = userIn.nextLine();

			Taokhoa();
			Mahoa(file_in, file_out);

			// Giai ma
			System.out.println();
			System.out.print("Nhap ten file ma hoa: ");
			file_in = userIn.nextLine();
			System.out.print("Nhap ten file da giai ma: ");
			file_out = userIn.nextLine();

			Giaima(file_in, file_out);
			userIn.close();

			System.out.print("Xong!");

		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
