package com.thigiacmaytinh.qrcodereader;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.TextView;
import android.widget.Toast;

import com.google.android.gms.common.api.CommonStatusCodes;
import com.google.android.gms.vision.barcode.Barcode;
import com.thigiacmaytinh.qrcodereader.barcode.BarcodeCaptureActivity;

public class ScanQRcodeActivity extends AppCompatActivity {
    TextView lblResult;
    int BARCODE_READER_REQUEST_CODE = 1;

    ////////////////////////////////////////////////////////////////////////////////////////////////

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.screen_scan_qr_code);

        setTitle("Scan QRcode");

        lblResult = findViewById(R.id.lblResult);
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////

    @Override
    public boolean onSupportNavigateUp(){
        finish();
        return true;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if (requestCode == BARCODE_READER_REQUEST_CODE) {
            if (resultCode == CommonStatusCodes.SUCCESS)
            {
                try {
                    Barcode barcode = data.getParcelableExtra("Barcode");
                    lblResult.setText(barcode.displayValue);
                }
                catch (Exception ex) {
                    Toast.makeText(this, ex.getMessage(), Toast.LENGTH_LONG).show();
                }
            }
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////

    public void btnScanQR_onclick(View view) {
        Intent intent = new Intent(this, BarcodeCaptureActivity.class);
        startActivityForResult(intent, BARCODE_READER_REQUEST_CODE);
    }

}
