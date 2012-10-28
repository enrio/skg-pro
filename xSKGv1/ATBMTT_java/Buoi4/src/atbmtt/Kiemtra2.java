package atbmtt;

import java.io.*;
import java.security.*;
import java.security.interfaces.*;
import java.security.spec.*;

public class Kiemtra2 {
	public static void main(String[] args) {
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

			// Khởi tạo kiểm tra chữ ký
			Signature signer = Signature.getInstance("MD5withRSA");
			signer.initVerify(kp);

			// Đọc file thông báo
			fis = new FileInputStream("c:\\thong-bao.txt");

			// Cắt dữ liệu ra từng khối, kích thước <= 117 bytes
			int size = 117;
			buff = new byte[size];

			while (true) {
				int n = fis.read(buff);
				if (n <= 0)
					break;
				signer.update(buff, 0, n);
			}
			fis.close();

			// Đọc file chữ ký
			fis = new FileInputStream("c:\\chu-ky2.txt");
			byte[] signatureData = new byte[fis.available()];
			fis.read(signatureData);
			fis.close();

			// Kiểm tra chữ ký
			if (signer.verify(signatureData))
				System.out.print("Chu ky dung");
			else
				System.out.print("Chu ky sai");

		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
